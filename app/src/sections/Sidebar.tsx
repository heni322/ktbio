import { NavLink } from 'react-router-dom';
import {
  LayoutDashboard,
  FolderTree,
  Users,
  Settings,
  ChevronLeft,
  ChevronRight,
  ClipboardList,
  MapPin,
  Package2
} from 'lucide-react';
import { Button } from '@/components/ui/button';

interface SidebarProps {
  isCollapsed: boolean;
  onToggle: () => void;
}

const menuItems = [
  { path: '/', icon: LayoutDashboard, label: 'Tableau de bord' },
  { path: '/familles', icon: FolderTree, label: 'Familles' },
  { path: '/sous-familles', icon: FolderTree, label: 'Sous-Familles' },
  { path: '/etats', icon: ClipboardList, label: 'États' },
  { path: '/depots', icon: MapPin, label: 'Dépôts' },
  { path: '/article-stock', icon: Package2, label: 'Stock Articles' },
  { path: '/utilisateurs', icon: Users, label: 'Utilisateurs' },
  { path: '/parametres', icon: Settings, label: 'Paramètres' },
];

export function Sidebar({ isCollapsed, onToggle }: SidebarProps) {
  return (
    <aside
      className={`bg-white border-r border-gray-200 h-[calc(100vh-64px)] transition-all duration-300 flex flex-col ${isCollapsed ? 'w-16' : 'w-64'
        }`}
    >
      <div className="flex-1 py-4 overflow-y-auto">
        <nav className="space-y-1 px-2">
          {menuItems.map((item) => (
            <NavLink
              key={item.path}
              to={item.path}
              end={item.path === '/'}
              className={({ isActive }) =>
                `flex items-center gap-3 px-3 py-2.5 rounded-lg transition-colors ${isActive
                  ? 'bg-[#3CBAAE] text-white'
                  : 'text-gray-700 hover:bg-gray-100'
                }`
              }
            >
              <item.icon className="h-5 w-5 flex-shrink-0" />
              {!isCollapsed && <span className="text-sm font-medium">{item.label}</span>}
            </NavLink>
          ))}
        </nav>
      </div>

      <div className="p-2 border-t border-gray-200">
        <Button
          variant="ghost"
          size="icon"
          onClick={onToggle}
          className="w-full flex items-center justify-center"
        >
          {isCollapsed ? (
            <ChevronRight className="h-5 w-5" />
          ) : (
            <ChevronLeft className="h-5 w-5" />
          )}
        </Button>
      </div>
    </aside>
  );
}
